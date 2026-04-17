namespace Frames
{
  // Initial Tx to Client with RSA Public Key
  public class ServerToClientRSAPublicKeyFrame
  {
  }
  // Initial Tx to Server with AES Secret Key and IV, encrypted by RSA Public Key
  public class ClientToServerRSAEncryptedAESSecret
  {

  }
  // General BiDirectional Tx of AES Encrypted Data, assume AES keys are already exchanged and set up,
  //   this is the "payload" frame for encrypted communication
  public class EncryptedMsgFrame
  {

  }
}
