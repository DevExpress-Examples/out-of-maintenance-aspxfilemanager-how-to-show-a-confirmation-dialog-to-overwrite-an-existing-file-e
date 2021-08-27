<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128554580/13.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4879)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# ASPxFileManager - How to show a confirmation dialog to overwrite an existing file
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4879/)**
<!-- run online end -->


<p>This example illustrates how to show a conformation message to overwrite an existing file in the ASPxFileManager.</p>
<p>The conformation message is shown in the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerScriptsASPxClientFileManager_FileUploadingtopic"><u>ASPxClientFileManager.FileUploading</u></a> event and gives an option to the user to either overwrite the existing file or cancel the operation. User's selection is then transferred to the server-side via an <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHiddenFieldASPxHiddenFieldMembersTopicAll"><u>ASPxHiddenField</u></a>. If the user chooses to overwrite the file, the existing file will be deleted.</p>
<p>This example is also available in MVC:<br> <a href="https://www.devexpress.com/Support/Center/p/E4880">FileManager - How to show a confirmation dialog to overwrite an existing file</a></p>


<h3>Description</h3>

<strong>Obsolete approach. Use a custom file system provider to manipulate files instead.</strong><br>If the user chooses to overwrite the file, the existing file will be deleted in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerASPxFileManager_FileUploadingtopic"><u>ASPxFileManager.FileUploading</u></a> event.

<br/>


