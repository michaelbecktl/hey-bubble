import { UserCredentials } from '../../models/models'
import request from 'superagent'

const rootURL = new URL(`http://localhost:8080/api/v1/user`)

export async function LoginUser(userLogin: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}/login`).send(userLogin)
    return response.body
  } catch (error) {
    console.log('Error logging in:', error)
  }
}

export async function RegisterUser(userDetails: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}/register`).send(userDetails)
    return response.body
  } catch (error) {
    console.error('Error registering user:', error)
  }
}
