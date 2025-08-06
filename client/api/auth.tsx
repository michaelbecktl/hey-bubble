import request from 'superagent'

const rootURL = new URL(`http://localhost:3000/auth`, document.baseURI)

export async function RegisterUser({
  username,
  email,
  password,
}: {
  username: string
  email: string
  password: string
}) {
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
