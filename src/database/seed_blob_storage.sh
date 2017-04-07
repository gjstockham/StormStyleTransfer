#!/bin/bash
# A simple Azure Storage example script

# Use the local emulator
# https://docs.microsoft.com/en-us/azure/storage/storage-use-emulator
# Put real keys in here if necessary
AZURE_CONNECTION_STRING="DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;"
# Tried to do this with exports but it didn't work...

CONTAINER_NAME="stormstyletransfer"

echo "Listing existing containers"
az storage container list --connection-string $AZURE_CONNECTION_STRING 

echo "Creating the container"
az storage container create -n $CONTAINER_NAME --connection-string $AZURE_CONNECTION_STRING 

echo "Uploading Models"
az storage blob upload -f ../../data/models/rain_princess.ckpt -c $CONTAINER_NAME -n EDEED513-F2D1-4FA3-B946-260069860995/rain_princess.ckpt --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/models/scream.ckpt -c $CONTAINER_NAME -n 30612E53-7E67-4A0D-B007-6587881C6A7A/scream.ckpt --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/models/wave.ckpt -c $CONTAINER_NAME -n 33C2BC64-ECDF-4C0C-A28D-99583AA55E23/wave.ckpt --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/models/udnie.ckpt -c $CONTAINER_NAME -n 0FEA59D5-6DEB-4CF4-A039-ACCB52F18970/udnie.ckpt --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/models/la_muse.ckpt -c $CONTAINER_NAME -n 705F37EB-6011-4FBD-A47A-B2A124E3B3E5/la_muse.ckpt --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/models/wreck.ckpt -c $CONTAINER_NAME -n 8D38B7FC-AC52-4930-A57C-CC7DB034990E/wreck.ckpt --connection-string $AZURE_CONNECTION_STRING 

echo "Uploading Reference images"
az storage blob upload -f ../../data/reference/rain_princess.jpg -c $CONTAINER_NAME -n EDEED513-F2D1-4FA3-B946-260069860995/rain_princess.jpg --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/reference/the_scream.jpg -c $CONTAINER_NAME -n 30612E53-7E67-4A0D-B007-6587881C6A7A/the_scream.jpg --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/reference/wave.jpg -c $CONTAINER_NAME -n 33C2BC64-ECDF-4C0C-A28D-99583AA55E23/wave.jpg --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/reference/udnie.jpg -c $CONTAINER_NAME -n 0FEA59D5-6DEB-4CF4-A039-ACCB52F18970/udnie.jpg --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/reference/la_muse.jpg -c $CONTAINER_NAME -n 705F37EB-6011-4FBD-A47A-B2A124E3B3E5/la_muse.jpg --connection-string $AZURE_CONNECTION_STRING 
az storage blob upload -f ../../data/reference/the_shipwreck_of_the_minotaur.jpg -c $CONTAINER_NAME -n 8D38B7FC-AC52-4930-A57C-CC7DB034990E/the_shipwreck_of_the_minotaur.jpg --connection-string $AZURE_CONNECTION_STRING 

