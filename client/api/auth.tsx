import request from 'superagent'

const rootURL = new URL(`http://localhost:3000/auth`, document.baseURI)

type UserCredentials = {
  username: string
  password: string
  email?: string
}

export async function LoginUser({ username, password }: UserCredentials) {
  try {
    const response = await request
      .post(`${rootURL}/login`)
      .send({ username, password })
    return response.body
  } catch (error) {
    console.log('Error logging in:', error)
  }
}

export async function RegisterUser({
  username,
  email,
  password,
}: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}/register`).send({
      username,
      email,
      password,
    })
    return response.body
  } catch (error) {
    console.error('Error registering user:', error)
  }
}
