export function getRelativeTimeString(date: Date | number) {
  const timeMs = typeof date === 'number' ? date : date.getTime()
  const deltaSeconds = Math.round((timeMs - Date.now()) / 1000)

  const cutoffs = [60, 3600, 86400, 86400 * 7, 86400 * 30, 86400 * 365, Infinity]
  const units = ['second', 'minute', 'hour', 'day', 'week', 'month', 'year'] as const

  const unitIndex = cutoffs.findIndex(cutoff => cutoff > Math.abs(deltaSeconds))

  const divisor = unitIndex ? cutoffs[unitIndex - 1] : 1
  const rtf = new Intl.RelativeTimeFormat('en', {
    numeric: 'auto',
  })

  const diff = Math.floor(deltaSeconds / divisor)
  const unit = units[unitIndex]

  if (unit === 'year' && Math.abs(diff) > 5) {
    return 'a long time ago'
  }

  return rtf.format(diff, unit)
}
