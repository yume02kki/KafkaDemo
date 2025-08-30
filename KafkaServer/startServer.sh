KAFKA_PATH="./kafka"
$KAFKA_PATH/bin/kafka-server-start.sh $KAFKA_PATH/config/server.properties &
$KAFKA_PATH/bin/kafka-topics.sh --create --topic person-topic --bootstrap-server localhost:9092 --if-not-exists
wait
