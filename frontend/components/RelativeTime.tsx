import { useEffect, useState } from 'react'
import AppText from './AppText'

function calculateRelativeTime(date: Date): string {
  const currentTime = new Date()
  const postDate = new Date(date)
  const timeDifference = Math.floor(
    (currentTime.getTime() - postDate.getTime()) / 1000
  )

  if (timeDifference < 60) return 'just now'
  if (timeDifference < 3600) return `${Math.floor(timeDifference / 60)}m`
  if (timeDifference < 86400) return `${Math.floor(timeDifference / 3600)}h`
  if (timeDifference < 604800) return `${Math.floor(timeDifference / 86400)}d`
  if (timeDifference < 2419200) return `${Math.floor(timeDifference / 604800)}w`

  return `${postDate.getDate()} ${postDate.getMonth()} ${postDate.getFullYear()}`
}

type Props = {
  date: Date
}

export function RelativeTime({ date }: Props) {
  const [text, setText] = useState(calculateRelativeTime(date))

  useEffect(() => {
    const refreshInterval = setInterval(() => {
      setText(calculateRelativeTime(date))
    }, 60000)

    return () => clearInterval(refreshInterval)
  }, [date])

  return <AppText text={text} type="sub" />
}
