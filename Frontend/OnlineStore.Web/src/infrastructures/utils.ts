async function request(
  url: string,
  httpMethod: string,
  header?: object,
  body?: object
) {
  const defaultHeader = { ...header };
  const response = await fetch(url, {
    headers: defaultHeader,
    method: httpMethod,
    body: JSON.stringify(body),
  });
  return await handleResponse(response);
}

async function handleResponse(response: Response) {
  if (response.status === 401) {
    // Invoke refresh token here
    return {};
  }
  if (response.ok && response.status === 200) {
    return await response.json();
  }
  throw new Error("Something when wrong, please try again later");
}

export default request;
