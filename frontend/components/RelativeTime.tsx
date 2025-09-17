import { useEffect, useState } from 'react'
import AppText from './AppText'

function calculateRelativeTime(date: Date): string {
  const currentTime = new Date()
  const postDate = new Date(date)
  const timeDifference = Math.floor(
    (currentTime.getTime() - postDate.getTime()) / 1000
  )

  function monthToString(num: number) {
    switch (num) {
      case 1:
        return 'Jan'
      case 2:
        return 'Feb'
      case 3:
        return 'Mar'
      case 4:
        return 'Apr'
      case 5:
        return 'May'
      case 6:
        return 'Jun'
      case 7:
        return 'Jul'
      case 8:
        return 'Aug'
      case 9:
        return 'Sep'
      case 10:
        return 'Oct'
      case 11:
        return 'Nov'
      case 12:
        return 'Dec'
    }
  }

  if (timeDifference < 60) return 'just now'
  if (timeDifference < 3600) return `${Math.floor(timeDifference / 60)}m`
  if (timeDifference < 86400) return `${Math.floor(timeDifference / 3600)}h`
  if (timeDifference < 604800) return `${Math.floor(timeDifference / 86400)}d`
  if (timeDifference < 2419200) return `${Math.floor(timeDifference / 604800)}w`

  return `${postDate.getDate()} ${monthToString(
    postDate.getMonth()
  )} ${postDate.getFullYear()}`
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
