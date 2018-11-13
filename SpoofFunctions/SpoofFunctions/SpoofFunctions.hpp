//
//  SpoofFunctions.hpp
//  SpoofFunctions
//
//  Created by User on 13/11/2018.
//  Copyright © 2018 User. All rights reserved.
//

#ifndef SpoofFunctions_hpp
#define SpoofFunctions_hpp

#include <stdio.h>
extern "C" int sub(int a, int b);
extern "C" int my_main_second(int argc, char** argv);
extern "C" void CSP_GetLastError();
extern "C" void CertCloseStore();
extern "C" void CertCreateCertificateContext();
extern "C" void CertFindCertificateInStore();
extern "C" void CertFindChainInStore();
extern "C" void CertFreeCertificateChain();
extern "C" void CertFreeCertificateContext();
extern "C" void CertGetCertificateChain();
extern "C" void CertGetIssuerCertificateFromStore();
extern "C" void CertNameToStrA();
extern "C" void CertOpenStore();
extern "C" void CertOpenSystemStoreA();
extern "C" void CertVerifyCertificateChainPolicy();
extern "C" void CryptAcquireCertificatePrivateKey();
extern "C" void CryptGetProvParam();
extern "C" void CryptReleaseContext();
extern "C" void CryptSetProvParam();
extern "C" void CryptStringToBinaryA();
extern "C" void InitSecurityInterfaceA();
extern "C" void MultiByteToWideChar();
extern "C" void support_load_library_getaddr();
extern "C" void support_load_library_registry();
#endif /* SpoofFunctions_hpp */
