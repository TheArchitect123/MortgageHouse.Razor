export class ImageModel {
  public ImageID: BigInteger;
  public UploadOBUAID: BigInteger;
  public DocumentTypeID: BigInteger;
  public ApplicationID: BigInteger;

  public UploadDate: Date;
  public RecordCreateDate: Date;

  public FileName: string;
  public ImageDescription: string;
  public ImageFilePath: string;
}
