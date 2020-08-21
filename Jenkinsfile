pipeline {
  agent { label 'DotNetCore'  }
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
        sh 'dotnet restore'
      }
    }

    stage('DotNetTest') {
      steps {
        sh 'dotnet test'
      }
    }

    stage('CodeCoverage') {
      steps {
        sh 'dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput="./TestResults/"'
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
