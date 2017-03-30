Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Class LanguageSelection
    Public ChooseLang As ChooseLanguage
    Public BaseLang As LanguageWrapper
   
    Public Shared IdToFavouriteListItem As New Dictionary(Of integer, FavoriteListViewItem)

    Const FromLangIndex = 1
    Const ToLangIndex = 2
    Const IdIndex = 3
    Const IdToItselfIndex = 4
    Const PhrasesEnd = 99

    Public Property AllCommonPhrases As New ObservableCollection(Of FavoriteListViewItem)
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
        Me.DataContext = Me
        FavoriteListViewItem.InitBase(BaseLang)
        Dim x As LanguageWrapper = LanguageWrapper.GetCurrentLanguage(1)
        For i=0 To PhrasesEnd
            If x.HasPhrase(i)
                AllCommonPhrases.Add(New FavoriteListViewItem(x, i))
            End If
        Next
        
    End Sub



    Private Sub ChooseLanguageMenuItem_Click(sender As Object, e As RoutedEventArgs) Handles ToolBarLangSelect.Click
        ChooseLang.ShowDialog()
    End Sub

    Private Sub ListBoxItem_Selected(sender As Object, e As RoutedEventArgs)
       'MsgBox(CType(VisualTreeHelper.GetChild(CType(sender, Image).Parent, IdToItselfIndex), Label).Content)
        GetFavListItem(sender).ChangeCheck
        'CType(sender, FavoriteListViewItem).ChangeCheck
    End Sub

    Private Function GetFavListItem(sender as Object) As FavoriteListViewItem
        return IdToFavouriteListItem(Integer.Parse(CType(VisualTreeHelper.GetChild(CType(sender, Image).Parent, IdToItselfIndex), Label).Content))
    End Function



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
    Shared Public Property AllPhrases As New ObservableCollection(Of FavoriteListViewItem)
End Class

Public Class FavoriteListViewItem : Implements INotifyPropertyChanged
    Public Shared DefaultBaseLang As LanguageWrapper

    Public ReadOnly Shared EmptyStar As New BitmapImage(New URI(("pack://application:,,,/images/empty_star.png")))
    Public ReadOnly Shared CloseStar As New BitmapImage(New URI(("pack://application:,,,/images/filled_star.png")))


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


    Property FromLang As String
    Property ToLang As String
    Private _imagePath As BitmapImage = EmptyStar

    Property ImagePath As BitmapImage 
        Get
            Return Me._imagePath
        End Get
        Set(value As BitmapImage)
            if Not value.Equals(Me._imagePath) Then
                _imagePath = value
                
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ImagePath"))
            End If
            
        End Set
    End Property

    Property IsChecked As Boolean = False
    Property Id As Integer ' the id of the word/phrase
    Property IdToItself As Integer ' an id to the instance of itself, taken from languageSelect.IdToFavouriteListItem

    private Shared _idCounter As Integer = 0

    Private Shared ReadOnly Property IdCounter As Integer
        Get
            dim temp as Integer = _idCounter
            _idCounter += 1
            return temp
        End Get
    End Property

    Sub NewHelper(fromlang as LanguageWrapper, toLang As LanguageWrapper, id As Integer)
         Me.id = id
        Me.FromLang = fromLang.GetPhrase(id)
        Me.ToLang = toLang.GetPhrase(id)
        Me.IdToItself = IdCounter
        LanguageSelection.IdToFavouriteListItem.Add(Me.IdToItself, Me)
    End Sub

    Sub New(fromlang as LanguageWrapper, toLang As LanguageWrapper, id As Integer)
       NewHelper(fromLang, toLang, id)
    End Sub

    Sub New(toLang As LanguageWrapper, id As Integer)
        If DefaultBaseLang Is Nothing
            Throw New Exception("Run InitBase() first to initalize a base language")
        End If

         NewHelper(DefaultBaseLang, toLang, id)
    End Sub

    Public Shared Sub InitBase(fromLang As LanguageWrapper)
        DefaultBaseLang = fromLang
    End Sub
    Public Sub ChangeCheck()
        IsChecked = Not IsChecked ' reveser it
        If IsChecked Then
            Me.ImagePath = CloseStar
        Else
            Me.ImagePath = EmptyStar
        End If
    End Sub
End Class


