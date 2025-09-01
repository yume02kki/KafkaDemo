#!/bin/bash
source .env
echo "Select container to run:"
echo "1) Kafka"
echo "2) OracleDB" 
echo "3) both"
read -p "> " choice
case $choice in
    1) docker compose -f $KAFKA up ;;
    2) docker compose -f $ORACLE_DB up ;;
    3) docker compose -f $KAFKA up -d && docker compose -f $ORACLE_DB up -d ;;
    *) echo "Invalid choice" ;;
esac
