package com.neurotec.tutorials.biometrics;

import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.io.File;
import java.io.IOException;
import java.util.EnumSet;

import com.neurotec.biometrics.NBiometricOperation;
import com.neurotec.biometrics.NBiometricStatus;
import com.neurotec.biometrics.NBiometricTask;
import com.neurotec.biometrics.NSubject;
import com.neurotec.biometrics.NVoice;
import com.neurotec.biometrics.client.NBiometricClient;
import com.neurotec.biometrics.client.NClusterBiometricConnection;
import com.neurotec.io.NFile;
import com.neurotec.samples.app.BaseActivity;
import com.neurotec.samples.app.DirectoryViewer;
import com.neurotec.samples.util.NSoundBufferUtils;
import com.neurotec.sound.NSoundBuffer;

public final class CreateVoiceTemplateOnServer extends BaseActivity {

	// ==============================================
	// Private static fields
	// ==============================================

	private static final String DEFAULT_IP = "127.0.0.1";
	private static final String DEFAULT_ADMIN_PORT = "24932";
	private static final String DEFAULT_CLIENT_PORT = "25452";
	private static final String TAG = CreateVoiceTemplateOnServer.class.getSimpleName();
	private static final int REQUEST_CODE_GET_FILE = 1;

	// ==============================================
	// Private fields
	// ==============================================

	private Button mButton;
	private TextView mResult;
	private EditText mIpAddress;
	private EditText mClientPortNumber;
	private EditText mAdminPortNumber;
	private ProgressDialog mProgressDialog;

	// ==============================================
	// Private methods
	// ==============================================

	private boolean validateAdminPort() {
		boolean validPort = true;
		validPort &= mAdminPortNumber.getText() != null;
		validPort &= !mAdminPortNumber.getText().toString().isEmpty();
		try {
			Integer.parseInt(mAdminPortNumber.getText().toString());
		} catch (NumberFormatException e) {
			validPort = false;
		}
		return validPort;
	}

	private boolean validateClientPort() {
		boolean validPort = true;
		validPort &= mClientPortNumber.getText() != null;
		validPort &= !mClientPortNumber.getText().toString().isEmpty();
		try {
			Integer.parseInt(mClientPortNumber.getText().toString());
		} catch (NumberFormatException e) {
			validPort = false;
		}
		return validPort;
	}

	private void getVoiceFile() {
		Intent intent = new Intent(this, DirectoryViewer.class);
		intent.putExtra(DirectoryViewer.ASSET_DIRECTORY_LOCATION, BiometricsTutorialsApp.TUTORIALS_ASSETS_DIR);
		startActivityForResult(intent, REQUEST_CODE_GET_FILE);
	}

	private void showMessage(final String message) {
		runOnUiThread(new Runnable() {
			@Override
			public void run() {
				mResult.append(message + "\n");
			}
		});
	}

	private void enroll(Uri voiceUri) throws IOException {
		NBiometricClient biometricClient = null;
		NClusterBiometricConnection connection = null;
		NSubject subject = null;
		NVoice voice = null;
		NSoundBuffer soundBuffer = NSoundBufferUtils.fromUri(this, voiceUri);
		NBiometricTask task = null;
		NBiometricStatus status = null;

		try {
			biometricClient = new NBiometricClient();
			connection = new NClusterBiometricConnection();
			subject = new NSubject();
			voice = new NVoice();

			// Perform all biometric operations on remote server only
			biometricClient.setLocalOperations(EnumSet.noneOf(NBiometricOperation.class));

			connection.setHost(mIpAddress.getText().toString());
			connection.setPort(Integer.parseInt(mClientPortNumber.getText().toString()));
			connection.setAdminPort(Integer.parseInt(mAdminPortNumber.getText().toString()));

			biometricClient.getRemoteConnections().add(connection);

			//Set voice file
			voice.setSoundBuffer(soundBuffer);

			subject.getVoices().add(voice);

			task = biometricClient.createTask(EnumSet.of(NBiometricOperation.CREATE_TEMPLATE), subject);

			biometricClient.performTask(task);

			if (task.getError() != null) {
				showError(task.getError());
				return;
			}

			if (subject.getVoices().size() > 1)
			showMessage(String.format("Found %d voices\n", subject.getVoices().size() - 1));

			status = task.getStatus();

			if (status == NBiometricStatus.OK) {
				// Save template to file.
				File outputFile = new File(BiometricsTutorialsApp.TUTORIALS_OUTPUT_DATA_DIR, "create-voice-template-on-server.dat");
				NFile.writeAllBytes(outputFile.getAbsolutePath(), subject.getTemplate().save());
				showMessage(getString(R.string.format_template_saved_to, outputFile.getAbsolutePath()));
			} else {
				showMessage(getString(R.string.format_extraction_failed, status.toString()));
			}
		} finally {
			if (biometricClient != null) biometricClient.dispose();
			if (connection != null) connection.dispose();
			if (subject != null) subject.dispose();
			if (voice != null) voice.dispose();
		}
	}

	// ==============================================
	// Protected methods
	// ==============================================

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tutorial_create_voice_template_on_server);
		mIpAddress = (EditText) findViewById(R.id.tutorials_field_1);
		mIpAddress.setHint(DEFAULT_IP);
		mClientPortNumber = (EditText) findViewById(R.id.tutorials_field_2);
		mClientPortNumber.setText(DEFAULT_CLIENT_PORT);
		mClientPortNumber.setHint("Client port, default - " + DEFAULT_CLIENT_PORT);
		mAdminPortNumber = (EditText) findViewById(R.id.tutorials_field_3);
		mAdminPortNumber.setText(DEFAULT_ADMIN_PORT);
		mAdminPortNumber.setHint("Admin port, defalut - " + DEFAULT_ADMIN_PORT);
		mButton = (Button) findViewById(R.id.tutorials_button_1);
		mButton.setText(R.string.msg_select_audio_file);
		mButton.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				if (mIpAddress.getText() == null || mIpAddress.getText().toString().isEmpty()) {
					showMessage(getString(R.string.msg_ip_not_valid));
				} else if (!validateAdminPort()) {
					showMessage(getString(R.string.msg_admin_port_not_valid));
				} else if (!validateClientPort()) {
					showMessage(getString(R.string.msg_client_port_not_valid));
				} else {
					getVoiceFile();
				}
			}
		});
		mResult = (TextView) findViewById(R.id.tutorials_results);
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		if ((mProgressDialog != null) && (mProgressDialog.isShowing())) {
			mProgressDialog.dismiss();
		}
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == REQUEST_CODE_GET_FILE) {
			if (resultCode == RESULT_OK) {
				try {
					enroll(data.getData());
				} catch (Exception e) {
					showMessage(e.getMessage());
					Log.e(TAG, "Exception", e);
				}
			}
		}
	}

}
