node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat "\"${MSBuild}\" /t:Restore BalticMarinasClient.sln"
		bat "\"${MSBuild}\" BalticMarinasClient.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
	
	stage 'Archive'
		archive 'BalticMarinasClient/bin/Release/**'
}