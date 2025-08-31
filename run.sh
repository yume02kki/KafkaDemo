#!/bin/bash
source .env
echo "Select container to run:"
echo "1) Kafka"
echo "2) OracleDB" 
echo "3) All"
read -p "> " choice
case $choice in
    1) sudo docker compose -f $KAFKA up -d ;;
    2) sudo docker compose -f $ORACLE_DB up -d ;;
    3) sudo docker compose -f $KAFKA up -d && sudo docker compose -f $ORACLE_DB up -d ;;
    *) echo "Invalid choice" ;;
esac
