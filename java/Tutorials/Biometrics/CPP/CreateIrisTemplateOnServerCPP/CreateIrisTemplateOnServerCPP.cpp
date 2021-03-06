#include <TutorialUtils.hpp>

#ifdef N_MAC_OSX_FRAMEWORKS
	#include <NCore/NCore.hpp>
	#include <NBiometricClient/NBiometricClient.hpp>
	#include <NBiometrics/NBiometrics.hpp>
	#include <NMedia/NMedia.hpp>
#else
	#include <NBiometrics.hpp>
	#include <NBiometricClient.hpp>
	#include <NCore.hpp>
	#include <NMedia.hpp>
#endif

using namespace std;
using namespace Neurotec;
using namespace Neurotec::Biometrics;
using namespace Neurotec::Biometrics::Client;
using namespace Neurotec::IO;

const NChar title[] = N_T("CreateIrisTemplateOnServer");
const NChar description[] = N_T("Demonstrates how to create iris template from image on server.");
const NChar version[] = N_T("9.0.0.0");
const NChar copyright[] = N_T("Copyright (C) 2016-2017 Neurotechnology");

const NChar * defaultServerIp = N_T("127.0.0.1");
const NInt defaultAdminPort = 24932;
const NInt defaultPort = 25452;

int usage()
{
	cout << "usage:" << endl;
	cout << "\t" << title << " [input image] [output template] [server] [port]" << endl << endl;
	cout << "\t[server] - matching server address." << endl;
	cout << "\t[port] - matching port address (if server address specified - port is optional)." << endl;
	cout << "\t[image]   - image filename to extract." << endl;
	cout << "\t[template] - filename to store extracted features." << endl;
	return 1;
}

int main(int argc, NChar **argv)
{
	OnStart(title, description, version, copyright, argc, argv);

	if (argc < 3)
	{
		OnExit();
		return usage();
	}
	try
	{
		NString serverIp = defaultServerIp;
		NInt adminPort = defaultAdminPort;
		if (argc == 4)
		{
			serverIp = argv[3];
		}
		if (argc == 5)
		{
			serverIp = argv[3];
			adminPort = atoi(argv[4]);
		}
		NClusterBiometricConnection clusterBiometricConnection(serverIp, defaultPort, adminPort);
		NBiometricClient biometricClient;
		biometricClient.SetLocalOperations(nboNone);
		biometricClient.GetRemoteConnections().Add(clusterBiometricConnection);
		NIris iris;
		iris.SetSampleBuffer(NFile::ReadAllBytes(argv[1]));
		NSubject subject;
		subject.GetIrises().Add(iris);
		biometricClient.SetIrisesTemplateSize(ntsLarge);
		NBiometricStatus status = biometricClient.CreateTemplate(subject);
		if (status == nbsOk)
			cout << "Template extracted" << endl;
		else
		{
			cout << "Extraction failed: " << NEnum::ToString(NBiometricTypes::NBiometricStatusNativeTypeOf(), status) << endl;
			return -1;
		}

		NFile::WriteAllBytes(argv[2], subject.GetTemplateBuffer());
		cout << "Template saved successfully" << endl;
	}
	catch (NError& ex)
	{
		return LastError(ex);
	}

	OnExit();
	return 0;
}
