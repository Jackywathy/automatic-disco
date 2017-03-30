Imports System.Collections.ObjectModel

Public Class TranslatorPage
    Private lang As LanguageWrapper

    Sub New(lang As LanguageWrapper)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lang = lang

    End Sub
End Class


Public Class ShowablePhrases
    Shared Property AllPhrases As New ObservableCollection(Of CheckedListItem)
End Class