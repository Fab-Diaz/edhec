#include <jni.h>
#include <string>

extern "C" JNIEXPORT jstring JNICALL
Java_epitech_edhec_MainActivity_stringFromJNI(
        JNIEnv *env,
        jobject /* this */) {
    std::string hello = "This is an test";
    return env->NewStringUTF(hello.c_str());
}
