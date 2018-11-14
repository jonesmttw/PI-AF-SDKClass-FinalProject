using ClosedXML.Excel;
using Newtonsoft.Json;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReportGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // initialize form system pi picker
            dbPicker.SystemPicker = piSystemPicker1;

            // Initialize Date Pickers to a 7 day time window ending at today's date
            dateEnd.Value = DateTime.Now;
            dateStart.Value = DateTime.Now.AddDays(-7);
        }

        private void dbPicker_SelectionChange(object sender, OSIsoft.AF.UI.SelectionChangeEventArgs e)
        {
            AFDatabase db = dbPicker.AFDatabase;

            if(db != null)
            {
                afTreeView.AFRoot = db.Elements;
            }
        }

        /// <summary>
        /// Toggles enabled status of children based UI Elements in the Application - toggled on checkbox click
        /// </summary>
        private void cbIncludeChildren_Click(object sender, EventArgs e)
        {
            cbChilrenAttributes.Enabled = cbReportOnChildren.Checked;
            cbParentAttributes.Enabled = !cbReportOnChildren.Checked;
        }

        /// <summary>
        /// After element selection within the Tree View - adjust the attribute selection checkboxes for exporting data
        /// </summary>
        private void afTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AFElement afElement = afTreeView.AFSelection as AFElement;

            // clear existing checkbox attribute items
            cbParentAttributes.Items.Clear();
            cbChilrenAttributes.Items.Clear();

            if (afElement != null)
            {
                // parents are a single element so you can add attributes directly
                cbParentAttributes.Items.AddRange(afElement.Attributes.Cast<AFAttribute>().ToArray());
                if (afElement.HasChildren)
                {
                    List<string> attributeNames = new List<string>();

                    // Need to loop throught the children elements in case there are different attributes per element
                    // build a list of the attribtue names for later exporting needs
                    foreach (AFElement element in afElement.Elements)
                    {
                        foreach (AFAttribute attribute in element.Attributes)
                        {
                            if (!attributeNames.Contains(attribute.Name))
                            {
                                attributeNames.Add(attribute.Name);
                            }
                        }
                    }

                    // after getting the different attribute names - add these to the checkbox list
                    cbChilrenAttributes.Items.AddRange(attributeNames.ToArray());
                }
            }
        }


        /// <summary>
        /// Returns an AFTimeRange based on the calendar date times from the form
        /// </summary>
        /// <returns>
        /// AFTimeRange from the date pickers
        /// </returns>
        private AFTimeRange GetTimeRangeFromDatePickers()
        {
            AFTime startTime = AFTime.Parse(dateStart.Value.ToShortDateString());
            AFTime endTime = AFTime.Parse(dateEnd.Value.ToShortDateString());

            return new AFTimeRange(startTime, endTime);
        }

        /// <summary>
        /// Writes data based on the form out to Excel
        /// </summary>
        /// <param name="outputFileLocation">String output file location to store Excel file</param>
        private void WriteDataToExcel(string outputFileLocation)
        {
            AFTimeRange timeRange = GetTimeRangeFromDatePickers();

            AFElement element = afTreeView.AFSelection as AFElement;

            // initialize dictionary to capture attribute name and the values for the attribute
            Dictionary<string, List<ReportCellValue>> values = new Dictionary<string, List<ReportCellValue>>();

            // initialize excel work book using ClosedXml
            XLWorkbook wb = new XLWorkbook();
            IXLWorksheet ws = wb.Worksheets.Add("AF Export");

            // export data from children or single element
            if (cbReportOnChildren.Checked)
            {
                int elementcount = 0;

                // loop through children elements
                foreach (AFElement children in element.Elements)
                {
                    // reset the values dictionary for the new child element and counter
                    values.Clear();
                    int tmpelementcount = 0;

                    foreach (AFAttribute attribute in children.Attributes)
                    {
                        // if the attribute is checked and the attribute supports the recorded values data retrieval method, get the values
                        if (cbChilrenAttributes.CheckedItems.Contains(attribute.Name) && attribute.SupportedDataMethods.HasFlag(AFDataMethods.RecordedValues))
                        {
                            // using Linq to do a Where AFValue is Good filter, convert these AFValues to ReportCellValue class for exporting to JSON or Excel
                            values[attribute.Name] = ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name);
                            tmpelementcount += values[attribute.Name].Count();
                        }
                    }

                    WriteDataToExcelWorksheet(ws, children.Name, values, elementcount);
                    elementcount += tmpelementcount;
                }
            }
            else
            {
                // if the attribute is checked, get the values
                foreach (AFAttribute attribute in cbParentAttributes.CheckedItems)
                {
                    // using Linq to do a Where AFValue is Good filter, convert these AFValues to ReportCellValue class for exporting to JSON or Excel
                    values[attribute.Name] = ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name);
                }

                WriteDataToExcelWorksheet(ws, element.Name, values, 0);

            }

            // save the excel file to the specified location
            wb.SaveAs(outputFileLocation);
            lblExcelCompleted.Visible = true;
        }

        /// <summary>
        /// Writes data directly into the Excel Workbook - used as a loop for different elements in the hierarchy
        /// </summary>
        /// <param name="ws">ClosedXML Worksheet to write data to</param>
        /// <param name="elementName">String Element name</param>
        /// <param name="values">Dictionary containing values to write to the different rows/columns</param>
        /// <param name="rowOffset">Integer row offset to help with row positioning</param>
        private void WriteDataToExcelWorksheet(IXLWorksheet ws, string elementName, Dictionary<string, List<ReportCellValue>> values, int rowOffset)
        {
            int cellCounter = 2;
            int rowCounter = 2 + rowOffset;
            foreach (string name in values.Keys)
            {
                ws.Cell(1, 1).Value = "Element";
                ws.Cell(1, cellCounter).Value = name;
                ws.Cell(1, cellCounter + 1).Value = String.Format("{0} Timestamps", name);

                // write the cell data based on the different values
                foreach(ReportCellValue celldata in values[name])
                {
                    ws.Cell(rowCounter, 1).Value = elementName;
                    ws.Cell(rowCounter, cellCounter).Value = celldata.Value;
                    ws.Cell(rowCounter, cellCounter + 1).Value = celldata.Timestamp;

                    rowCounter++;
                }

                // update row offset and cell counter to write data to the correct row and cell
                cellCounter = cellCounter + 2;
                rowCounter = 2 + rowOffset;
            }
        }

        /// <summary>
        /// Writes data based on the form out to the text box to preview the data as JSON
        /// </summary>
        private void WriteDataToJson()
        {
            AFTimeRange timeRange = GetTimeRangeFromDatePickers();

            AFElement element = afTreeView.AFSelection as AFElement;

            // initialize dictionary to capture attribute name and the values for the attribute
            Dictionary<string, List<ReportCellValue>> values = new Dictionary<string, List<ReportCellValue>>();

            // export data from children or single element
            if (cbReportOnChildren.Checked)
            {
                // loop through children elements
                foreach (AFElement children in element.Elements)
                {
                    foreach (AFAttribute attribute in children.Attributes)
                    {
                        // if the attribute is checked and the attribute supports the recorded values data retrieval method, get the values
                        if (cbChilrenAttributes.CheckedItems.Contains(attribute.Name) && attribute.SupportedDataMethods.HasFlag(AFDataMethods.RecordedValues))
                        {
                            // if the dictionary doesn't contain the attribute already, initialize the key value pair, otherwise add to the list
                            if (!values.Keys.Contains(children.Name))
                            {
                                values[children.Name] = ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name);
                            }
                            else
                            {
                                values[children.Name].AddRange(ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name));
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (AFAttribute attribute in cbParentAttributes.CheckedItems)
                {
                    // if the dictionary doesn't contain the attribute already, initialize the key value pair, otherwise add to the list
                    if (!values.Keys.Contains(element.Name))
                    {
                        values[element.Name] = ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name);
                    }
                    else
                    {
                        values[element.Name].AddRange(ConvertAFValuesToReportCellValues(attribute.Data.RecordedValues(timeRange, AFBoundaryType.Interpolated, null, null, true).Where(v => v.IsGood), attribute.Name));
                    }
                }
            }

            // display the json data in the text area
            txtJsonData.Text = JsonConvert.SerializeObject(values);
        }

        /// <summary>
        /// Converts an AFValue object to a ReportCellValue object to be used in either excel or serialized to JSON
        /// </summary>
        /// <param name="values">IENumerable object of AFVAlues</param>
        /// <param name="attributeName">String attribute name</param>
        /// <returns>
        /// List of ReporctCellValue objects
        /// </returns>
        private List<ReportCellValue> ConvertAFValuesToReportCellValues(IEnumerable<AFValue> values, string attributeName)
        {
            List<ReportCellValue> cells = new List<ReportCellValue>();
            
            // loop through values and create a new ReportCellValue based on the AFValues
            foreach(AFValue value in values)
            {
                cells.Add(new ReportCellValue()
                {
                    Name = attributeName,
                    Value = value.Value,
                    Timestamp = value.Timestamp.LocalTime,
                    Unit = value.UOM != null ? value.UOM.Abbreviation : string.Empty
                });
            }

            return cells;
        }

        /// <summary>
        /// Event Handler to begin exporting data to Excel
        /// </summary>
        private void btnExportData_MouseClick(object sender, MouseEventArgs e)
        {
            lblExcelCompleted.Visible = false;

            saveExcelDialog.ShowDialog();
        }

        /// <summary>
        /// Event Handler to begin converting data to preview in JSON
        /// </summary>
        private void btnPreviewData_MouseClick(object sender, MouseEventArgs e)
        {
            WriteDataToJson();
        }

        /// <summary>
        /// Event Handler to begin exporting data to Excel
        /// </summary>
        private void saveExcelDialog_FileOk(object sender, CancelEventArgs e)
        {
            WriteDataToExcel(saveExcelDialog.FileName);
        }
    }
}
