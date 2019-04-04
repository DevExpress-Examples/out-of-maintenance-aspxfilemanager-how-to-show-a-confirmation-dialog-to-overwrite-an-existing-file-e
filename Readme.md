<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ConfirmDialog/Default.aspx) (VB: [Default.aspx](./VB/ConfirmDialog/Default.aspx))
* [Default.aspx.cs](./CS/ConfirmDialog/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ConfirmDialog/Default.aspx.vb))
* [Global.asax](./CS/ConfirmDialog/Global.asax) (VB: [Global.asax](./VB/ConfirmDialog/Global.asax))
* [Global.asax.cs](./CS/ConfirmDialog/Global.asax.cs) (VB: [Global.asax.vb](./VB/ConfirmDialog/Global.asax.vb))
<!-- default file list end -->
# ASPxFileManager - How to show a confirmation dialog to overwrite an existing file


<p>This example illustrates how to show a conformation message to overwrite an existing file in the ASPxFileManager.</p>
<p>The conformation message is shown in the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerScriptsASPxClientFileManager_FileUploadingtopic"><u>ASPxClientFileManager.FileUploading</u></a> event and gives an option to the user to either overwrite the existing file or cancel the operation. User's selection is then transferred to the server-side via an <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHiddenFieldASPxHiddenFieldMembersTopicAll"><u>ASPxHiddenField</u></a>. If the user chooses to overwrite the file, the existing file will be deleted.</p>
<p>This example is also available in MVC:<br> <a href="https://www.devexpress.com/Support/Center/p/E4880">FileManager - How to show a confirmation dialog to overwrite an existing file</a></p>


<h3>Description</h3>

<p>This scenario should be implemented using a custom file system provider along with the&nbsp;<a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerASPxFileManager_FileUploadingtopic">ASPxFileManager.FileUploading</a>&nbsp;event.&nbsp;<br><br>In the&nbsp;<a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerASPxFileManager_FileUploadingtopic">ASPxFileManager.FileUploading</a>&nbsp;event handler,&nbsp;fetch&nbsp;a value from the ASPxHiddenField control and see if a user confirmed that he/she wants to override the existing file. Set the custom file system provider's flag accordingly. Implement the&nbsp;<a href="https://documentation.devexpress.com/AspNet/DevExpressWebFileSystemProviderBase_Existstopic.aspx">Exists</a>&nbsp;and <a href="https://documentation.devexpress.com/AspNet/DevExpressWebFileSystemProviderBase_UploadFiletopic.aspx">UploadFile</a>&nbsp;methods of the custom file system provider in the following manner:</p>
<code lang="cs">public override bool Exists(FileManagerFile file) {
    if (ProviderOptions.AllowOverwrite)
        return false;
    return base.Exists(file);
}
public override void UploadFile(FileManagerFolder folder, string fileName, Stream content) {
    base.UploadFile(folder, fileName, content);
    ProviderOptions.AllowOverwrite = false;
}
</code>
<p>&nbsp;</p>
<p>The main point of the approach is to explicitly specify that the file that is being uploaded does not exist if a user decided to override a file. The rest of the logic is implemented by the default PhysicalFileSystemProvider's methods.</p>

<br/>


