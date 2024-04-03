#!/bin/bash

echo "<br>" >> /html/index.html
ifconfig |grep -e "inet addr:10." |cut -d"Bcast" -f1 >> /html/index.html


nginx -g "daemon off;"
