# PI-AF-SDKClass-FinalProject
GitHub repository to store and deliver my final project for the PI AF SDK class

Created a WinForm application to generate dynamic excel exports for any available AF Database.  The report can be focused on an individual element or children elements based on the treeview selection. Most of this could probably be done in PI DataLink, however, I was looking for a good use case for leveraging the AF SDK to tackle a problem we see on a daily basis from clients: "Can I get a _______ export of these few columns A, B, C for this time frame in Excel".

As a side note - I prefer JSON over Excel. So for me to visualize the data as JSON seemed like a good fit.

### To Use the App

Make sure the dependencies from NuGet are installed, and launch the application.  Select your PI Server (which will connect automatically) and AF Database. On the Elements selection, you can either select an invidual element or parent element in a hierarchy. The checkbox lists to the right of the treeview will update based on your selection.  If you wish to export data on the children elements: check the box at the bottom of the treeview "Report on Children Elements". Continue to select your calendar start and finish times, then you can decide your exporting options. If you wish to just view the JSON contents, click the "Preview Data as JSON" button. If you would like to view the data in Excel, click the "Export to Excel" button and select your save location.

### Dependencies
* [PI AF SDK](https://techsupport.osisoft.com/Downloads/All-Downloads/Filters/All/All/All/Current/Developer-Technologies)
* [ClosedXML](https://github.com/ClosedXML/ClosedXML)
* [Newtonsoft.JSON](https://www.newtonsoft.com/json)