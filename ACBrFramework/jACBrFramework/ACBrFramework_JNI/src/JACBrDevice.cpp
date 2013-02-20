#include <stdlib.h>

#include "jni.h"
#include "JNIHelper.h"

#include "ACBrDevice.h"
#include "JACBrDevice.h"


JNIEXPORT jint JNICALL Java_jACBrFramework_ACBrDevice_getBaud(JNIEnv *env, jobject obj)
{
	return GetInt(&DEV_GetBaud, env, obj);
}

JNIEXPORT void JNICALL Java_jACBrFramework_ACBrDevice_setBaud(JNIEnv *env, jobject obj, jint baud)
{
	SetInt(&DEV_SetBaud, env, obj, baud);
}

JNIEXPORT jstring JNICALL Java_jACBrFramework_ACBrDevice_getPorta(JNIEnv *env, jobject obj)
{
	return GetString(&DEV_GetPorta, env, obj);
}

JNIEXPORT void JNICALL Java_jACBrFramework_ACBrDevice_setPorta(JNIEnv *env, jobject obj, jstring porta)
{
	SetString(&DEV_SetPorta, env, obj, porta);
}

