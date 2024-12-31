Imports System
Imports System.Net
Imports System.Text


Public Module WhoIsDis

    ' Module constants
    Const WHOIS_SERVER = "whois.verisign-grs.com"
    Const WHOIS_PORT = 43

    Const BUFFER_SIZE As Int16 = 8192
    Const OUTPUT_CAPTION_DOMAIN As String = "WHOIS data for: "

    Function Connect(domain As String)

        Dim ipHost As IPHostEntry = Dns.GetHostEntry(WHOIS_SERVER)
        Dim ip As IPAddress = ipHost.AddressList(0)
        Dim ipEndpoint As IPEndPoint = New IPEndPoint(ip, WHOIS_PORT)
        Dim sock As Net.Sockets.Socket = New Sockets.Socket(ipEndpoint.AddressFamily, Sockets.SocketType.Stream, Sockets.ProtocolType.Tcp)

        sock.Connect(ipEndpoint)

        Dim query As String = domain + Environment.NewLine
        Dim queryBytes As Byte() = Encoding.UTF8.GetBytes(query)
        sock.Send(queryBytes)

        Dim buffer(BUFFER_SIZE) As Byte
        sock.Receive(buffer)

        Return Encoding.UTF8.GetString(buffer)

    End Function

    ' Parsing function for the response string
    ' Takes the whole string response and splits on newlines into an array of useful individual lines
    Public Function Parse(response As String)

        Dim lines As String()
        lines = response.Split(Environment.NewLine)

        ' Take the first 9 elements, which are the most useful For simple domain information
        ' Strip extraneous elements And terms Of service messages from the WHOIS server
        Dim data(9) As String
        For i As Int16 = 0 To 9
            data(i) = (lines(i))
        Next

        Return data

    End Function

    ' Output formatted data to the command line
    Sub Output(domain As String, data As String())

        Console.WriteLine(OUTPUT_CAPTION_DOMAIN + domain)

        For Each line As String In data
            Console.WriteLine(line)
        Next

    End Sub

    ' Public sub for querying the Whois server
    Public Sub WhoIs(domain As String)

        Dim response As String = Connect(domain)

        Dim data As String() = Parse(response)

        Output(domain, data)

    End Sub

    Sub Main(args As String())

        If args.Length = 1 Then
            WhoIs(args(0))
        Else
            Console.WriteLine("Usage: WhoIsDis.exe <domain>")
        End If

    End Sub

End Module
