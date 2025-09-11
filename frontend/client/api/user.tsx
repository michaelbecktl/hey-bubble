import { UserCredentials } from '../../models/models'
import request from 'superagent'

const rootURL = new URL(`http://192.168.50.59:5218/api/v1/user`)

export async function LoginUser(userLogin: UserCredentials) {
  try {
    const response = await request.post(`${rootURL}/login`).send(userLogin)
    return response.text
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

export async function GetCurrentUserProfile({
  token,
}: {
  token: string | null
}) {
  try {
    const response = await request.get(`${rootURL}/profile/current`)
    return response.body
  } catch (error: any) {
    throw error
  }
}

export async function GetUserProfileById({
  token,
  userId,
}: {
  token: string | null
  userId: number
}) {
  try {
    const response = await request.get(`${rootURL}/profile/${userId}`)
    return response.body
  } catch (error: any) {
    throw error
  }
}
