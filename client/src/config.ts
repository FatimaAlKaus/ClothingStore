const port = 5000;
const host = 'http://localhost';
const homeAddress = `${host}:${port}/api`;
export const config = {
  host,
  port,
  homeAddress,
  productPhotoFolder: `${host}:${port}/StaticFiles/ProductPhotos/`,
};
