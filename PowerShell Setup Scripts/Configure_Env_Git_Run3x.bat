# Run script 3 times because of the deeply nested variables
# PROXY_USERNAME is the username used to connect to proxy.
# May be different than the existing USERNAME (account you logged into VM with, like 'Administrator')

# Primary variables (CHANGE THESE FIRST!)
setx PROXY_HOSTNAME           my_domain.com
setx PROXY_USERNAME           my_user
setx PROXY_PASSWORD           my_password
setx PROXY_SERVER             my_server
setx PROXY_PORT               my_port
 
# Secondary variables
setx HTTP_PROXY               "http://%PROXY_USERNAME%:%PROXY_PASSWORD%@%PROXY_SERVER%.%PROXY_HOSTNAME%:%PROXY_PORT%"
setx HTTPS_PROXY              %HTTP_PROXY%
setx FTP_PROXY                %HTTP_PROXY%
setx ALL_PROXY                %HTTP_PROXY%
setx NO_PROXY                 "localhost,127.0.0.1,*.%PROXY_HOSTNAME%,%USERDOMAIN%"

# Misc variables
setx GIT_CURL_VERBOSE         1
setx GIT_SSL_NO_VERIFY        1

# close and re-open the current command prompt to see changes
exit