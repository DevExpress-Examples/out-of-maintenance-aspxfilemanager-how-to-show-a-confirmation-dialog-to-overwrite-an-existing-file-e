Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ConfirmDialog
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Private Property ProviderOptions() As MyCustomProviderOptions

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            FileManager.CustomFileSystemProvider = CreateCustomFileSystemProvider()
        End Sub

        Private Function CreateCustomFileSystemProvider() As FileSystemProviderBase
            ProviderOptions = New MyCustomProviderOptions()
            Dim provider As New MyCustomFileSystemProvider(FileManager.Settings.RootFolder, ProviderOptions)

            Return provider
        End Function

        Protected Sub ASPxFileManager1_FileUploading(ByVal source As Object, ByVal e As FileManagerFileUploadEventArgs)
            ProviderOptions.AllowOverwrite = Convert.ToBoolean(HiddenField("overwrite"))
        End Sub
    End Class

    Public Class MyCustomFileSystemProvider
        Inherits PhysicalFileSystemProvider

        Private Property ProviderOptions() As MyCustomProviderOptions

        Public Sub New(ByVal rootFolder As String, ByVal providerOptions As MyCustomProviderOptions)
            MyBase.New(rootFolder)
            Me.ProviderOptions = providerOptions
        End Sub
        Public Overrides Function Exists(ByVal file As FileManagerFile) As Boolean
            If ProviderOptions.AllowOverwrite Then
                Return False
            End If
            Return MyBase.Exists(file)
        End Function
        Public Overrides Sub UploadFile(ByVal folder As FileManagerFolder, ByVal fileName As String, ByVal content As System.IO.Stream)
            MyBase.UploadFile(folder, fileName, content)
            ProviderOptions.AllowOverwrite = False
        End Sub
    End Class

    Public Class MyCustomProviderOptions
        Public Property AllowOverwrite() As Boolean
    End Class
End Namespace