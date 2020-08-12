pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/core/sdk:3.1'
      args '''-u root
-v /var/run/docker.sock:/var/run/docker.sock'''
    }
  }
  stages {
    stage('Print a Message') {
      steps {
        sh 'hostname'
        echo 'Setting Path'
        sh 'set'
        sh 'pwd'
        sh '/usr/share/dotnet/dotnet -h'
      }
    }

    stage('DotNetRestore') {
      steps {
        sh 'hostname'
        sh 'whoami'
        sh 'set'
        sh 'dotnet restore'
      }
    }

    stage('DotNetTest') {
      steps {
        sh 'dotnet test'
      }
    }

 

 
  }
  environment {
    DOTNET_CLI_HOME = '/usr/share/dotnet'
  }
  post {
    always {
      sh 'chmod -R 777 .'
      cleanWs()
    }
  }
}
