Public NotInheritable Class Logger

    Public Shared Sub Log(message As Object)
        IO.File.AppendAllText(".\MAS.log", DateTime.Now & ":" & message & Environment.NewLine)
    End Sub
End Class