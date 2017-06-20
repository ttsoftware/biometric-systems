#include <TutorialUtils.hpp>

#ifdef N_MAC_OSX_FRAMEWORKS
	#include <NCore/NCore.hpp>
	#include <NBiometricClient/NBiometricClient.hpp>
	#include <NBiometrics/NBiometrics.hpp>
	#include <NMedia/NMedia.hpp>
	#include <NLicensing/NLicensing.hpp>
#else
	#include <NCore.hpp>
	#include <NBiometricClient.hpp>
	#include <NBiometrics.hpp>
	#include <NMedia.hpp>
	#include <NLicensing.hpp>
#endif

using namespace std;
using namespace Neurotec;
using namespace Neurotec::Licensing;
using namespace Neurotec::Biometrics;
using namespace Neurotec::Biometrics::Client;

const NChar title[] = N_T("VerifyVoice");
const NChar description[] = N_T("Demonstrates voice verification.");
const NChar version[] = N_T("9.0.0.0");
const NChar copyright[] = N_T("Copyright (C) 2016-2017 Neurotechnology");

int usage()
{
	cout << "usage:" << endl;
	cout << "\t" << title << " [reference voice] [candidate voice]" << endl;
	return 1;
}

static NSubject CreateSubject(const NStringWrapper& fileName, const NStringWrapper& subjectId)
{
	NSubject subject;
	NVoice voice;
	voice.SetFileName(fileName);
	subject.SetId(subjectId);
	subject.GetVoices().Add(voice);
	return subject;
}

int main(int argc, NChar **argv)
{
	const NChar * components = N_T("Biometrics.VoiceExtraction,Biometrics.VoiceMatching");
	OnStart(title, description, version, copyright, argc, argv);

	if (argc < 3)
	{
		OnExit();
		return usage();
	}

	try
	{
		if (!NLicense::ObtainComponents(N_T("/local"), N_T("5000"), components))
		{
			NThrowException(NString::Format(N_T("Could not obtain licenses for components: {S}"), components));
		}

		NSubject referenceSubject = CreateSubject(argv[1],argv[1]);
		NSubject candidateSubject = CreateSubject(argv[2],argv[2]);
		NBiometricClient biometricClient;
		biometricClient.SetMatchingThreshold(48);
		NBiometricStatus status = biometricClient.Verify(referenceSubject, candidateSubject);
		if (status == nbsOk || status == nbsMatchNotFound)
		{
			cout << "Voice score: " << referenceSubject.GetMatchingResults().Get(0).GetScore() << ", verification.. ";
			if (status == nbsOk)
			{
				cout << "Succeeded" << endl;
			}
			else
			{
				cout << "Failed" << endl;
			}
		}
		else
		{
			cout << "Verification failed. Status: " << NEnum::ToString(NBiometricTypes::NBiometricStatusNativeTypeOf(), status) << endl;
			return -1;
		}
	}
	catch (NError& ex)
	{
		return LastError(ex);
	}

	NLicense::ReleaseComponents(components);
	OnExit();
	return 0;
}
