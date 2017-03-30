Imports System.Collections.ObjectModel

Class MainWindow
    Private ReadOnly ButtonList As New List(Of Button)

    Sub InitExtras()
        ButtonList.Add(lang1)
        ButtonList.Add(lang2)
        ButtonList.Add(lang3)
        ButtonList.Add(lang4)
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        InitExtras()
        LanguageWrapper.LoadDefaultLanguages()
        For i = 0 To 3
            ButtonList(i).Content = LanguageWrapper.GetCurrentLanguage(i).GetPhrase(103) 'Choose { lang } for main language
        Next i
    End Sub


    Private Sub NextForm(index4Loaded As Integer)
        Dim oForm As New LanguageSelection(LanguageWrapper.GetCurrentLanguage(index4Loaded))
        oForm.Show
        Me.Close
    End Sub

    Private Sub lang1_Click(sender As Object, e As RoutedEventArgs) Handles lang1.Click
        NextForm(0)
    End Sub

    Private Sub lang2_Click(sender As Object, e As RoutedEventArgs) Handles lang2.Click
        NextForm(1)
    End Sub

    Private Sub lang3_Click(sender As Object, e As RoutedEventArgs) Handles lang3.Click
        NextForm(2)
    End Sub

    Private Sub lang4_Click(sender As Object, e As RoutedEventArgs) Handles lang4.Click
        NextForm(3)
    End Sub
End Class


