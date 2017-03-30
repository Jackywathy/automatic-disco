Imports System.Collections.ObjectModel

Public Class LanguageSelection
    Public ChooseLang As ChooseLanguage
    Public BaseLang As LanguageWrapper
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Sub New(baseLang As LanguageWrapper)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'lbl_choose.Content = language
        BaseLang = baseLang
        LblTranslator.Content = baseLang.GetPhrase(102) ' translator
        ' init some language selection stuff
        ChooseLang = New ChooseLanguage()
      
    End Sub



    Private Sub ChooseLanguageMenuItem_Click(sender As Object, e As RoutedEventArgs) Handles ToolBarLangSelect.Click
        ChooseLang.ShowDialog()
    End Sub



    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub
    
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        ChooseLang.Close
    End Sub

    Private Sub Window_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        LblTranslator.FontSize = Math.Min(Me.Width, Me.Height) * 0.07
    End Sub
End Class


Public Class SavedPhrases
    Shared Property AllPhrases As New ObservableCollection(Of CheckedListItem)
End Class

Public Class ConstHelpers
  
End Class

