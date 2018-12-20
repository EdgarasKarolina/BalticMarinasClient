pipeline
	{
	agent none
		stages
		{
			stage('Checkout')
			{
				steps
				{
					script
					{
						node 
						{
							checkout scm
						}
					}
				}
			}
			stage('Test')
			{
				steps
				{
					script
					{
						node 
						{
							bat "\"${MSBuild}\" /t:Restore BalticMarinasClient.sln"
							bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"C:/Users/Edgaras/Desktop/Final Project/BalticMarinas/BalticMarinasClient/BalticMarinasClient.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
						}
					}
				}
			}
			stage('Archive')
			{
				steps
				{
					script
					{
						node 
						{
							archive 'BalticMarinasClient/bin/Release/**'
						}
					}
				}
			}
	}
		post
		{
			failure
				{
					mail to: 'attendancesystemkea@gmail.com',
					subject: "Failed Pipeline: ${currentBuild.fullDisplayName}",
					body: "Something is wrong with ${env.BUILD_URL}"
					echo "sent"
				}
	    }
	}