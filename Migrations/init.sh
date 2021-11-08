#!/bin/sh
sed -i "s|--ServiceUsername--|$4|g" ./init.sql
sed -i "s|--ServicePassword--|$5|g" ./init.sql

/opt/mssql-tools/bin/sqlcmd -S "$1" -U "$2" -P "$3" -i ./init.sql