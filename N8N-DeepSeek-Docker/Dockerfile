FROM ollama/ollama:latest

# Copy the script into the container
COPY entrypoint.sh /entrypoint.sh

# Make the script executable
RUN chmod +x /entrypoint.sh

# Set the ENTRYPOINT to the script
ENTRYPOINT ["/bin/sh", "/entrypoint.sh"]