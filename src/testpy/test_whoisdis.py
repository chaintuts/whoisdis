# This file contains unit tests for the WhoIsDis application functionality
#
# Author: Josh McIntyre
#
import hashlib
import unittest
from unittest.mock import patch, Mock

import whoisdis

class TestWhoIsDis(unittest.TestCase):

    SAMPLE_RESPONSE = "    Domain Name: CHAINTUTS.COM\r\n   Registry Domain ID: 2328653928_DOMAIN_COM-VRSN\r\n   Registrar WHOIS Server: whois.namecheap.com\r\n   Registrar URL: http://www.namecheap.com\r\n   Updated Date: 2024-10-03T06:15:58Z\r\n   Creation Date: 2018-11-02T15:12:26Z\r\n   Registry Expiry Date: 2025-11-02T15:12:26Z\r\n   Registrar: NameCheap, Inc.\r\n   Registrar IANA ID: 1068\r\n   Registrar Abuse Contact Email: abuse@namecheap.com\r\n   Registrar Abuse Contact Phone: +1.6613102107\r\n   Domain Status: clientTransferProhibited https://icann.org/epp#clientTransferProhibited\r\n   Name Server: DNS1.REGISTRAR-SERVERS.COM\r\n   Name Server: DNS2.REGISTRAR-SERVERS.COM\r\n   DNSSEC: unsigned\r\n   URL of the ICANN Whois Inaccuracy Complaint Form: https://www.icann.org/wicf/\r\n>>> Last update of whois database: 2024-12-31T19:19:18Z <<<\r\n\r\nFor more information on Whois status codes, please visit https://icann.org/epp\r\n\r\nNOTICE:"

    def test_parse(self):
        
        data = whoisdis._parse(self.SAMPLE_RESPONSE)
        print(data)
        
        # Assert we get the domain name in the first parsed line,
        # but not the Registry Domain ID string from the second line
        assert "CHAINTUTS.COM" in data[0]
        assert "Registry Domain ID" not in data[0]
        assert "Registry Domain ID" in data[1]
        
        assert "NameCheap" in data[7]

    
