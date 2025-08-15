import { UserCredentials } from '../../models/models'
import request from 'superagent'

const rootURL = new URL(`http://192.168.50.59:5218/api/v1/user`)

export async function LoginUser(userLogin: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}/login`).send(userLogin)
    return response.body.id
  } catch (error: any) {
    throw error
  }
}

export async function RegisterUser(userDetails: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}`).send(userDetails)
    return response.body
  } catch (error: any) {
    throw error
  }
}
