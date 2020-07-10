export class ImageModel {
  public image_id: BigInteger;
  public upload_obua_id: BigInteger;
  public document_type_id: BigInteger;
  public last_download_obua_id: BigInteger;

  public upload_date: Date;
  public Record_Create_Date: Date;
  public last_download_timestamp: Date;

  public description: string;
  public filename: string;
  public imagePath: string;
}

