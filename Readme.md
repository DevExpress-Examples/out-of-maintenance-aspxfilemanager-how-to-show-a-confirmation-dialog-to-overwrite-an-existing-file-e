# ASPxFileManager - How to show a confirmation dialog to overwrite an existing file


<p>This example illustrates how to show a conformation message to overwrite an existing file in the ASPxFileManager.</p>
<p>The conformation message is shown in the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerScriptsASPxClientFileManager_FileUploadingtopic"><u>ASPxClientFileManager.FileUploading</u></a> event and gives an option to the user to either overwrite the existing file or cancel the operation. User's selection is then transferred to the server-side via an <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHiddenFieldASPxHiddenFieldMembersTopicAll"><u>ASPxHiddenField</u></a>. If the user chooses to overwrite the file, the existing file will be deleted.</p>
<p>This example is also available in MVC:<br> <a href="https://www.devexpress.com/Support/Center/p/E4880">FileManager - How to show a confirmation dialog to overwrite an existing file</a></p>


<h3>Description</h3>

<strong>Obsolete approach. Use a custom file system provider to manipulate files instead.</strong><br>If the user chooses to overwrite the file, the existing file will be deleted in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerASPxFileManager_FileUploadingtopic"><u>ASPxFileManager.FileUploading</u></a> event.

<br/>


