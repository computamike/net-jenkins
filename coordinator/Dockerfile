FROM jenkins/jenkins:latest
COPY plugins.txt /usr/share/jenkins/ref/plugins.txt
#COPY casc_config/jenkins.yaml /var/jenkins_home/casc_configs/jenkins.yaml
RUN /usr/local/bin/install-plugins.sh < /usr/share/jenkins/ref/plugins.txt
# RUN /usr/local/bin/install-plugins.sh git mstest matrix-auth cobertura code-coverage-api workflow-aggregator docker-workflow blueocean credentials-binding ws-cleanup
ENV JENKINS_USER admin
ENV JENKINS_PASS admin
ENV CASC_JENKINS_CONFIG /var/jenkins_home/casc_configs/jenkins.yaml
USER root
# Install the latest Docker CE binaries and add user `jenkins` to the docker group
RUN apt-get update && \
    apt-get -y --no-install-recommends install apt-transport-https \
      ca-certificates \
      nano \
      curl \
      gnupg2 \
      software-properties-common && \
    curl -fsSL https://download.docker.com/linux/$(. /etc/os-release; echo "$ID")/gpg > /tmp/dkey; apt-key add /tmp/dkey && \
    add-apt-repository \
      "deb [arch=amd64] https://download.docker.com/linux/$(. /etc/os-release; echo "$ID") \
      $(lsb_release -cs) \
      stable" && \
   apt-get update && \
   apt-get -y --no-install-recommends install docker-ce && \
   apt-get clean && \
   usermod -aG docker jenkins
USER jenkins
# Skip initial setup
ENV JAVA_OPTS -Djenkins.install.runSetupWizard=false

COPY nodes/DotNetCore /var/jenkins_home/nodes/DotNetCore
VOLUME /var/jenkins_home
