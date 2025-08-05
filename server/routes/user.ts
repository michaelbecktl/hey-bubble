import { Router } from 'express'

const router = Router()

router.get('/', async (req, res) => {
  try {
    res.json('We got no users now')
  } catch (error) {
    console.log('Error obtaining all users', error)
    res.status(500).json({ message: '' })
  }
})
