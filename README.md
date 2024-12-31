## General
____________

### Author
* Josh McIntyre

### Website
* jmcintyre.net

### Overview
* WhoIsDis is a tool for fetching domain WHOIS information via the standard protocol

## Development
________________

### Git Workflow
* development for bugfixes and new features

### Building
* Build using Visual Studio for Visual Basic.NET version
* For Python version, copy scripts to desired directory

### Features
* Provide domain name via command line
* The tool will fetch WHOIS registration information using the standard protocol on port 43
* Parses out the most useful/common lines and displays via command line
* Uses the default provider for .com/.net domains `whois.verisign-grs.com` - can easily be modified for any other provider

### Requirements
* Requires the .NET framework
* Requires Python for the Python version

### Platforms
* Windows
* Linux
* Mac OSX

## Usage
____________

### CLI Usage
* Run `WhoIsDis.exe <domain>` to fetch WHOIS information via the command-line
* Run `python3 whoisdis.py <domain>` for the Python version

### Unit Tests
* Run Visual Basic.NET unit tests using Visual Studio Code
* Run Python unit tests with `pytest test_whoisdis.py`
