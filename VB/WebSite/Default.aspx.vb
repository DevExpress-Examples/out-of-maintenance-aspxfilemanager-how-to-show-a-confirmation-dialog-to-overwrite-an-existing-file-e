Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub ASPxFileManager1_FileUploading(ByVal source As Object, ByVal e As DevExpress.Web.ASPxFileManager.FileManagerFileUploadEventArgs)
			'Comment these lines to upload the file************************
			e.Cancel = True
			Throw New Exception("upload is not allowed in online examples ")
			'**************************************************************

			If Convert.ToBoolean(ASPxHiddenField1("overwrite")) Then
				Dim existFile = ASPxFileManager1.SelectedFolder.GetFiles().FirstOrDefault(Function(f) f.Name.Equals(e.FileName, StringComparison.InvariantCultureIgnoreCase))
				If existFile IsNot Nothing Then
					File.Delete(Path.Combine(MapPath("~"), existFile.RelativeName)) ' A path depends on the RootFolder in the file manager
				End If
			End If

	End Sub

End Class