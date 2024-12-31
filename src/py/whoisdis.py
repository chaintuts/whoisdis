# This file contains code for talking to a whois server over the standard protocol
#
# Author: Josh McIntyre
#
import argparse
import socket

# Define module constants

WHOIS_SERVER = "whois.verisign-grs.com"
WHOIS_PORT = 43

QUERY_TERMINATOR = "\r\n"
BUFFER_SIZE = 8192
BUFFER_CHUNK_SIZE = 256

OUTPUT_CAPTION_DOMAIN = "WHOIS data for: {}"

# Function for talking to the whois server
# Returns the response string from the server for parsing
def _connect(domain):
    
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.connect((WHOIS_SERVER, WHOIS_PORT))
    
    sock.send(f"{domain}{QUERY_TERMINATOR}".encode())

    response = b""
    while len(response) < BUFFER_SIZE:
        chunk = sock.recv(BUFFER_CHUNK_SIZE)
        if not chunk:
            break
        response += chunk

    return response.decode()

# Parsing function for the response string
# Takes the whole string and splits on newlines into a list of useful individual lines
def _parse(response):
    
    # Split data on newlines into a list
    data = response.splitlines()

    # Take the first 9 elements, which are the most useful for simple domain information
    # Strip extraneous elements and terms of service messages from the WHOIS server
    data = data[:10]
    
    return data
    
# Formatted output function for the data
def _output(domain, data):
    
    print(OUTPUT_CAPTION_DOMAIN.format(domain))
    
    for line in data:
        print(line)
    
# Public function for querying the whois server
def whois(domain):
    
    response = _connect(domain)
    print(repr(response))
    data = _parse(response)
    
    _output(domain, data)

# The main entry point for the program
def main():
    
    parser = argparse.ArgumentParser(description="Get WHOIS information about a domain using the standard protocol")
    parser.add_argument("--domain", type=str, required=True, help="The domain to look up")
    args = parser.parse_args()
    
    whois(args.domain)
   
if __name__ == "__main__":
    main()