export var parseRequestUrl = () => {
  const url = document.location.hash.toLowerCase();
  var request = url.split("/");
  return {
    resource: request[1],
    id: request[2],
    action: request[3],
  };
};
