Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace TestWhoIsDis
    <TestClass>
    Public Class TestWhoIsDis

        Const SAMPLE_RESPONSE As String = "    Domain Name: CHAINTUTS.COM\r\n   Registry Domain ID: 2328653928_DOMAIN_COM-VRSN\r\n   Registrar WHOIS Server: whois.namecheap.com\r\n   Registrar URL: http://www.namecheap.com\r\n   Updated Date: 2024-10-03T06:15:58Z\r\n   Creation Date: 2018-11-02T15:12:26Z\r\n   Registry Expiry Date: 2025-11-02T15:12:26Z\r\n   Registrar: NameCheap, Inc.\r\n   Registrar IANA ID: 1068\r\n   Registrar Abuse Contact Email: abuse@namecheap.com\r\n   Registrar Abuse Contact Phone: +1.6613102107\r\n   Domain Status: clientTransferProhibited https://icann.org/epp#clientTransferProhibited\r\n   Name Server: DNS1.REGISTRAR-SERVERS.COM\r\n   Name Server: DNS2.REGISTRAR-SERVERS.COM\r\n   DNSSEC: unsigned\r\n   URL of the ICANN Whois Inaccuracy Complaint Form: https://www.icann.org/wicf/\r\n>>> Last update of whois database: 2024-12-31T19:19:18Z <<<\r\n\r\nFor more information on Whois status codes, please visit https://icann.org/epp\r\n\r\nNOTICE:"
        <TestMethod>
        Sub TestParse()

            Dim formatSampleResponse As String = SAMPLE_RESPONSE.Replace("\r\n", Environment.NewLine)

            Dim data As String() = WhoIsDis.Parse(formatSampleResponse)

            ' Assert we Get the domain name In the first parsed line,
            ' but Not the Registry Domain ID String from the second line
            Assert.IsTrue(data(0).Contains("CHAINTUTS.COM"))
            Assert.IsFalse(data(0).Contains("Registry Domain ID"))
            Assert.IsTrue(data(1).Contains("Registry Domain ID"))

            Assert.IsTrue(data(7).Contains("NameCheap"))

        End Sub

    End Class

End Namespace

