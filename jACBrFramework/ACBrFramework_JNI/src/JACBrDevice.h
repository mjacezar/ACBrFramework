#ifndef _jACBrFramework_Device_H_
#define _jACBrFramework_Device_H_

#include "jni.h"

#ifdef __cplusplus
extern "C" {
#endif


JNIEXPORT jint JNICALL Java_jACBrFramework_ACBrDevice_getBaud(JNIEnv *env, jobject obj);
JNIEXPORT void JNICALL Java_jACBrFramework_ACBrDevice_setBaud(JNIEnv *env, jobject obj, jint baud);

JNIEXPORT jstring JNICALL Java_jACBrFramework_ACBrDevice_getPorta(JNIEnv *env, jobject obj);
JNIEXPORT void JNICALL Java_jACBrFramework_ACBrDevice_setPorta(JNIEnv *env, jobject obj, jstring porta);

#ifdef __cplusplus
} /* extern "C" */
#endif /* __cplusplus */

#endif