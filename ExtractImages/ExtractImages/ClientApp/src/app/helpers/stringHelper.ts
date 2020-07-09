export class StringHelper {
  public static isEmpty(str): boolean {
    return !str || 0 === str.length;
  }
}
