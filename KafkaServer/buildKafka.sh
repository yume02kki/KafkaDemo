KAFKA_PATH="./kafka"
KAFKA_CLUSTER_ID="$($KAFKA_PATH/bin/kafka-storage.sh random-uuid)"
$KAFKA_PATH/bin/kafka-storage.sh format --standalone -t $KAFKA_CLUSTER_ID -c $KAFKA_PATH/config/server.properties
