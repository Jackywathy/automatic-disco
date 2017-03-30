Imports System.IO
Imports Newtonsoft.Json

Public Class LanguageWrapper
    Public Shared LoadedLanguages As New Dictionary(Of String, LanguageWrapper)
    Public Shared FourCurrentLanguages As New List(Of String)
    ' lowercase(language) : language obj
    Private WordToID As New Dictionary(Of String, Integer)
    Private IDtoWord As New Dictionary(Of Integer, String)

    ' required for deserializing !
    Property Language As String
    Property Country As String
    Property Description As String
    Public Phrases As Dictionary(Of String, String)


    'required for deserializing!

    ' id to language

    Sub UpdateDictionary()
        For Each pair As KeyValuePair(Of String, String) In Phrases
            ' id to language
            WordToID.Add(pair.Value, pair.Key)
            ' language to id
            IDtoWord.Add(pair.Key, pair.Value)
        Next pair
    End Sub

    Shared Function ReadJson(itemlocation As String) As LanguageWrapper
        Using reader As New StreamReader(itemlocation)
            Dim json As String = reader.ReadToEnd
            Dim newlang = JsonConvert.DeserializeObject(Of LanguageWrapper)(json)
            newlang.UpdateDictionary()
            newlang.Phrases = Nothing
            Return newlang
        End Using
    End Function

    Public Shared Function LoadEng() As LanguageWrapper
        Dim english As New LanguageWrapper("English", "England", "")
        english.AddPhrase(0, "Hello")
        english.AddPhrase(1, "Do you speak English?")
        english.AddPhrase(100, "Choose your language")
        english.AddPhrase(102, "Universal Translator")
        english.AddPhrase(103, "Use English as main language")

        english.AddPhrase(200, "English")
        english.AddPhrase(201, "Chinese")
        english.AddPhrase(202, "German")
        english.AddPhrase(203, "Russian")

        english.AddPhrase(999, "No Data :(")

        Return english
    End Function

    Public Shared Function LoadChn() As LanguageWrapper
        Dim chinese As New LanguageWrapper("Chinese", "China", "")
        chinese.AddPhrase(0, "你好")
        chinese.AddPhrase(1, "你会说英语吗?")
        chinese.AddPhrase(100, "选择你的语言")
        chinese.AddPhrase(102, "通用翻译")
        chinese.AddPhrase(103, "选择中文为主要语言")
        

        chinese.AddPhrase(200, "英语")
        chinese.AddPhrase(201, "中文")
        chinese.AddPhrase(202, "德语")
        chinese.AddPhrase(203, "俄语")

        chinese.AddPhrase(999, "没有数据 :(")
        Return chinese
    End Function

     Public Shared Function LoadGer() As LanguageWrapper
        Dim german As New LanguageWrapper("German", "Germany", "")
        german.AddPhrase(0, "Hallo")
        german.AddPhrase(1, "sprichst du Englisch")
        german.AddPhrase(100, "Wähle deine Sprache")
        german.AddPhrase(102, "Übersetzer")
        german.AddPhrase(103, "Deutsch als Hauptsprache benutzen")

        german.AddPhrase(200, "Englisch")
        german.AddPhrase(201, "Chinesisch")
        german.AddPhrase(202, "Deutsche")
        german.AddPhrase(203, "Russisch")

        german.AddPhrase(999, "Keine Daten :(")
        Return german
    End Function

    Public Shared Function LoadRus() As LanguageWrapper
        Dim russian As New LanguageWrapper("Russian", "Russia", "")
        russian.AddPhrase(0, "Здравствуйте")
        russian.AddPhrase(1, "Ты говоришь по-английски?")
        russian.AddPhrase(100, "Выберите ваш язык")
        russian.AddPhrase(102, "Универсальный переводчик")
        russian.AddPhrase(103, "Выберите русский для основного языка")

        russian.AddPhrase(200, "английский")
        russian.AddPhrase(201, "Китайский")
        russian.AddPhrase(202, "Немецкий")
        russian.AddPhrase(203, "русский")

        russian.AddPhrase(999, "Нет данных :(")
        Return russian
    End Function


    Public Shared Sub LoadDefaultLanguages()
        Load4CurrentLangs()

        LoadLanguageIntoLoaded(LoadEng)
        LoadLanguageIntoLoaded(LoadChn)
        LoadLanguageIntoLoaded(LoadGer)
        LoadLanguageIntoLoaded(LoadRus)
    End Sub

    Shared Sub Load4CurrentLangs()
        FourCurrentLanguages.Add("english")
        FourCurrentLanguages.Add("chinese")
        FourCurrentLanguages.Add("german")
        FourCurrentLanguages.Add("russian")
    End Sub

    Shared Sub LoadLanguageIntoLoaded(lang As LanguageWrapper)
        LoadedLanguages.Add(lang.Language.ToLower(), lang)
    End Sub

    Shared Function GetCurrentLanguage(index As Integer) As LanguageWrapper
        Return LoadedLanguages(FourCurrentLanguages(index))
    End Function


    Sub New(language As String, country As String, Optional description As String = "")
        Me.Language = language
        Me.Country = country
        Me.Description = description
    End Sub

    Sub AddPhrase(id As Integer, word As String)
        WordToID.Add(word, id)
        IDtoWord.Add(id, word)
    End Sub

    Sub AddPhrase(word As String, id As Integer)
        WordToID.Add(word, id)
        IDtoWord.Add(id, word)
    End Sub

    Function GetPhrase(id As Integer) As String
        Dim phrase = ""
        If IDtoWord.TryGetValue(id, phrase) Then
            Return phrase
        End If
        If id = 999 Then ' tried to get the "no data entry", but failed, return english
            Return "No Entry for language :("
        End If
        Return GetPhrase(999)
    End Function
End Class


