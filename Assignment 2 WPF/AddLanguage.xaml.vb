Imports System.Collections.ObjectModel

Imports Newtonsoft.Json

Public Class ChooseLanguage
    Private ReadOnly ImportDialog As New Microsoft.Win32.OpenFileDialog

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        
    End Sub

    Private Sub SetupElements()
        ImportDialog.DefaultExt = ".json"
        ImportDialog.Filter = "JSON object (*.json)|*.json|All files (*.*)|*.*"
        CheckBoxes.Add("English")
        CheckBoxes.Add("Chinese")
        CheckBoxes.Add("German")
        CheckBoxes.Add("Russian")
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As RoutedEventArgs) Handles ImportButton.Click
        Dim result As Boolean = ImportDialog.ShowDialog
        If result Then
            Try
                Dim newLang As LanguageWrapper = LanguageWrapper.ReadJson(ImportDialog.FileName)
                CheckBoxes.AllLanguages.Add(New CheckedListItem(newLang.Language))
            Catch ex As JsonReaderException
                MessageBox.Show("An error occured while reading this language file", "An Error Occured", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End If
    End Sub

    Private Sub LanguageListView_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles LanguageListView.MouseDown
        CheckBoxes.UpdateEnableBoxes()
    End Sub
    
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupElements()
    End Sub

End Class


Public Class CheckedListItem


    Property Name As String
    Property IsChecked As Boolean
        Get
            Return Me._isChecked
        End Get

        Set(ByVal value As Boolean)
            If Not (value = _isChecked) Then
                Me._isChecked = value
                CheckBoxes.UpdateEnableBoxes()
            End If
        End Set
    End Property
    Private _isChecked As Boolean

    Property IsEnabled As Boolean




    Sub New(name As String, Optional isChecked As Boolean? = Nothing, Optional isEnabled As Boolean? = Nothing)
        Me.Name = name
        ' first check if there is a custom valued pass in, else
        ' if there is already maximum languages selected, dont make it checked
        Me.IsChecked = If(IsNothing(isChecked), CheckBoxes.HasRemaining, isChecked)
        ' if there are languages left, enable the control + check it (above)
        Me.IsEnabled = If(IsNothing(isEnabled), CheckBoxes.HasRemaining, isEnabled)
    End Sub

End Class

Public Class CheckBoxes


    Const MaxLanguages = 4
    Shared Property AllLanguages As New ObservableCollection(Of CheckedListItem)



    Shared Function HasRemaining() As Boolean
        Return GetTotalChecked() < MaxLanguages
    End Function

    Shared Sub ForceUpdate()
        Dim temp As New List(Of CheckedListItem)
        temp.AddRange(AllLanguages)
        AllLanguages.Clear()
        For Each item As CheckedListItem In temp
            AllLanguages.Add(item)
        Next
    End Sub

    Shared Sub UpdateEnableBoxes()
        If GetTotalChecked() < 4 Then
            For Each check As CheckedListItem In AllLanguages
                check.IsEnabled = True
            Next
            ForceUpdate()
        Else
            For Each check As CheckedListItem In AllLanguages
                If Not check.IsChecked Then
                    check.IsEnabled = False
                End If
            Next
            ForceUpdate()
        End If
    End Sub

    Shared Sub Add(name As String)
        Dim ncheck As New CheckedListItem(name)
        AllLanguages.Add(ncheck)

    End Sub

    Shared Function GetTotalChecked() As Integer

        Dim total = 0
        For Each check As CheckedListItem In AllLanguages
            If check.IsChecked Then
                total += 1
            End If
        Next
        Return total
    End Function

End Class